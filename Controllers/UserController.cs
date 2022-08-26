
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAPI.DBHelper;
using PracticeAPI.Model;

namespace PracticeAPI.Controllers 
{
    [ApiController]
    [Route("api/[controller]")] // as controller is using the same name as UserController (i.e. User)
    public class UserController : Controller
    {
 
        private readonly UserDbContext dbContext;

        public UserController(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet, Route("~/api/userList")]
        public async Task<IActionResult> GetUsers() {
            return Ok(await dbContext.UserDetails.ToListAsync());
        }

        [HttpGet,Route("~/api/getUser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var data = dbContext.UserDetails.Where(e => e.UserID == userId).FirstOrDefault();

            if (data == null) 
            {
                return NotFound(); 
            }

            return Ok(data);
        }


        [HttpPost, Route("~/api/addUser")]
        public async Task<IActionResult> AddUsers(AddUserDetailModel addUserDetail)
        {

            var data = new UserDetailModel();

            {
                data.UserID = addUserDetail.UserID;
                data.UserName = addUserDetail.UserName;
                data.UserEmail = addUserDetail.UserEmail;
                data.UserAddress = addUserDetail.UserAddress;
                data.UserContact = addUserDetail.UserContact;                
            }

           await  dbContext.UserDetails.AddAsync(data);
           await dbContext.SaveChangesAsync();

         return Ok(data);
        }



        /*[HttpPut]
        [Route("{userID:int}")]*/  // ====> For update userDetail by using userId 

        [HttpPut, Route("~/api/updateUser")]
        public async Task<IActionResult> updateUser(/*[FromRoute]*/ int userID, UpdateUserDetailModel updateUserDetail)
        {
         var data =  dbContext.UserDetails.Where(e=>e.UserID==userID).FirstOrDefault();
            if (data != null) {

                data.UserName = updateUserDetail.UserName;
                data.UserEmail = updateUserDetail.UserEmail;
                data.UserAddress = updateUserDetail.UserAddress;
                data.UserContact = updateUserDetail.UserContact;

                await  dbContext.SaveChangesAsync();
                return Ok(updateUserDetail);
            }
            return NotFound();
        }


        /*[HttpDelete]
        [Route("{userID:int}")] */ // For delete userDetail by using userId 

        [HttpDelete, Route("~/api/deleteUser")]
        public async Task<IActionResult> deleteUser(/*[FromRoute]*/ int userID)
        {
            var data = await dbContext.UserDetails.Where(e=>e.UserID==userID).FirstOrDefaultAsync();
            if (data != null)
            {
                dbContext.Remove(data);
                await  dbContext.SaveChangesAsync();
                return Ok(data);
            }
            return NotFound();
        }

    }
}
