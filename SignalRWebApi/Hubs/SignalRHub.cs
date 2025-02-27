using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRWebApi.Hubs
{
    //hub sunucu görevi görecek dağıtım işlemi hubs sınıfı hnagisiyse onun üzeirnden yapıcaz
    public class SignalRHub:Hub
    {
        SignalRContext context = new SignalRContext();
       
        public async Task SendCategoryCount() // client tarafında gelince bu methot  ınvoke ile  çağrılacak 
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value); //bu method içindeki ReceiveCategoryCount kullan 
        }
    }
}
