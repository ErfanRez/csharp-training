using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ContactUs.ViewComponents
{
    public class MessagesViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
           return await Task.FromResult(View("TableMessage",DataBase.DataBase.Messages));
        }
    }
}