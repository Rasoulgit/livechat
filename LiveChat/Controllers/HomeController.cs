using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LiveChat.Models;
using LiveChat.Domain.Chat.Abstract;
using System.Threading.Tasks;
using System.Linq;
using LiveChat.Domain.Chat.Concrete;

namespace LiveChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomService roomService;
        public HomeController(ILogger<HomeController> logger,
            IRoomService roomService)
        {
            _logger = logger;

            this.roomService = roomService;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await roomService.GetAllAsync();

            var homeViewModel = new HomeViewModel
            {
                Rooms = rooms.ToDictionary(x => x.Id, y => y.Name)
            };


            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
