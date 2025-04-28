// SignalR ile sunucudaki "SignalRHub" adlý Hub'a baðlantý kuruyoruz.
var connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7087/SignalRHub") // Hub URL'si
    .build();

// Sayfa ilk açýldýðýnda "Mesaj Gönder" butonunu devre dýþý býrakýyoruz.
// Çünkü baðlantý henüz kurulmadý.
document.getElementById("sendMessage").disabled = true;

// Sunucudan "ReceiveMessage" olayý tetiklendiðinde çalýþacak olan fonksiyon.
// Sunucu mesaj gönderdiðinde bu fonksiyon tetikleniyor.
connection.on("ReceiveMessage", function (user, message) {
    // Þu anki zamaný alýyoruz (mesajýn saatini göstermek için)
    var currentTime = new Date();
    var currentHour = currentTime.getHours(); // Saati alýyoruz (örn: 14)
    var currentMinute = currentTime.getMinutes(); // Dakikayý alýyoruz (örn: 30)

    // Bir <li> (liste elemaný) oluþturuyoruz (mesajý göstereceðimiz yer)
    var li = document.createElement("li");

    // Kullanýcý adýný kalýn (bold) yazmak için bir <span> oluþturuyoruz.
    var span = document.createElement("span");
    span.style.fontWeight = "bold"; // Kalýn yazý stili veriyoruz
    span.innerText = user + ": "; // Kullanýcýnýn adýný ve yanýna ":" ekliyoruz

    // Span'ý li'nin içine ekliyoruz
    li.appendChild(span);

    // Sonra mesaj içeriðini ve saatini li'nin içine yazýyoruz
    li.innerHTML += `${message} - ${currentHour}:${currentMinute}`;

    // Son olarak <ul id="messageList"> içine bu yeni mesajý ekliyoruz
    document.getElementById("messageList").appendChild(li);
});

// Baðlantý baþlatýlýyor.
connection.start().then(function () {
    // Baðlantý baþarýlý olunca "Mesaj Gönder" butonunu aktif hale getiriyoruz.
    document.getElementById("sendMessage").disabled = false;
}).catch(function (err) {
    // Baðlantý baþarýsýz olursa hatayý konsola yazdýrýyoruz.
    return console.error(err.toString());
});

// "Mesaj Gönder" butonuna týklandýðýnda çalýþacak olan fonksiyon
document.getElementById("sendMessage").addEventListener("click", function (event) {
    // Kullanýcý adýný input'tan alýyoruz ve baþtaki/sondaki boþluklarý siliyoruz
    const user = document.getElementById("userInput").value.trim();
    // Mesajý input'tan alýyoruz ve baþtaki/sondaki boþluklarý siliyoruz
    const message = document.getElementById("messageInput").value.trim();

    // Eðer hem kullanýcý adý hem de mesaj boþ deðilse
    if (user && message) {
        // Sunucuya "SendMessage" adýndaki metodu çaðýrýp kullanýcý adý ve mesajý gönderiyoruz.
        connection.invoke("SendMessage", user, message).catch(function (err) {
            // Hata olursa hatayý konsola yazdýrýyoruz
            return console.error(err.toString());
        });
        // Mesaj gönderildikten sonra mesaj input'unu temizliyoruz
        document.getElementById("messageInput").value = "";
    } else {
        // Eðer kullanýcý adý veya mesaj boþsa kullanýcýya uyarý veriyoruz
        alert("Ýsim ve mesaj boþ olamaz!");
    }

    // Sayfanýn varsayýlan form gönderme davranýþýný engelliyoruz (sayfa yenilenmesin diye)
    event.preventDefault();
});
