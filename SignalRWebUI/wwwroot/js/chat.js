// SignalR ile sunucudaki "SignalRHub" adl� Hub'a ba�lant� kuruyoruz.
var connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7087/SignalRHub") // Hub URL'si
    .build();

// Sayfa ilk a��ld���nda "Mesaj G�nder" butonunu devre d��� b�rak�yoruz.
// ��nk� ba�lant� hen�z kurulmad�.
document.getElementById("sendMessage").disabled = true;

// Sunucudan "ReceiveMessage" olay� tetiklendi�inde �al��acak olan fonksiyon.
// Sunucu mesaj g�nderdi�inde bu fonksiyon tetikleniyor.
connection.on("ReceiveMessage", function (user, message) {
    // �u anki zaman� al�yoruz (mesaj�n saatini g�stermek i�in)
    var currentTime = new Date();
    var currentHour = currentTime.getHours(); // Saati al�yoruz (�rn: 14)
    var currentMinute = currentTime.getMinutes(); // Dakikay� al�yoruz (�rn: 30)

    // Bir <li> (liste eleman�) olu�turuyoruz (mesaj� g�sterece�imiz yer)
    var li = document.createElement("li");

    // Kullan�c� ad�n� kal�n (bold) yazmak i�in bir <span> olu�turuyoruz.
    var span = document.createElement("span");
    span.style.fontWeight = "bold"; // Kal�n yaz� stili veriyoruz
    span.innerText = user + ": "; // Kullan�c�n�n ad�n� ve yan�na ":" ekliyoruz

    // Span'� li'nin i�ine ekliyoruz
    li.appendChild(span);

    // Sonra mesaj i�eri�ini ve saatini li'nin i�ine yaz�yoruz
    li.innerHTML += `${message} - ${currentHour}:${currentMinute}`;

    // Son olarak <ul id="messageList"> i�ine bu yeni mesaj� ekliyoruz
    document.getElementById("messageList").appendChild(li);
});

// Ba�lant� ba�lat�l�yor.
connection.start().then(function () {
    // Ba�lant� ba�ar�l� olunca "Mesaj G�nder" butonunu aktif hale getiriyoruz.
    document.getElementById("sendMessage").disabled = false;
}).catch(function (err) {
    // Ba�lant� ba�ar�s�z olursa hatay� konsola yazd�r�yoruz.
    return console.error(err.toString());
});

// "Mesaj G�nder" butonuna t�kland���nda �al��acak olan fonksiyon
document.getElementById("sendMessage").addEventListener("click", function (event) {
    // Kullan�c� ad�n� input'tan al�yoruz ve ba�taki/sondaki bo�luklar� siliyoruz
    const user = document.getElementById("userInput").value.trim();
    // Mesaj� input'tan al�yoruz ve ba�taki/sondaki bo�luklar� siliyoruz
    const message = document.getElementById("messageInput").value.trim();

    // E�er hem kullan�c� ad� hem de mesaj bo� de�ilse
    if (user && message) {
        // Sunucuya "SendMessage" ad�ndaki metodu �a��r�p kullan�c� ad� ve mesaj� g�nderiyoruz.
        connection.invoke("SendMessage", user, message).catch(function (err) {
            // Hata olursa hatay� konsola yazd�r�yoruz
            return console.error(err.toString());
        });
        // Mesaj g�nderildikten sonra mesaj input'unu temizliyoruz
        document.getElementById("messageInput").value = "";
    } else {
        // E�er kullan�c� ad� veya mesaj bo�sa kullan�c�ya uyar� veriyoruz
        alert("�sim ve mesaj bo� olamaz!");
    }

    // Sayfan�n varsay�lan form g�nderme davran���n� engelliyoruz (sayfa yenilenmesin diye)
    event.preventDefault();
});
