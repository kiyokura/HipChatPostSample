using System.Linq;
using System.Web.Mvc;
using HipchatApiV2;
using HipchatApiV2.Requests;
using HipchatApiV2.Enums;


namespace HipChatPostSample.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      var client = new HipchatClient();
      var rooms = client.GetAllRooms();
      var selectList = new SelectList(rooms.Items, "Id", "Name");
      ViewBag.room = selectList; 
      return View();
    }

    [HttpPost]
    public ActionResult PostMesasge(string message, int room)
    {
      var client = new HipchatClient();
      var request = new SendRoomNotificationRequest()
      {
        Message = message,
        MessageFormat = HipchatMessageFormat.Text,
        Notify = true,
        Color = RoomColors.Purple
      };
      client.SendNotification(room, request);
      return RedirectToAction("Index");
    }
  }
}