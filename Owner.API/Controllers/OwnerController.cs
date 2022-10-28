using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        public  List<Owner> OwnerList = new List<Owner>()
        {
           new Owner
           {
              Id=1,
              Name = "Ali",
              Surname="Öz",
              Date=new DateTime(2022,09,09),
              Explanition="Explanation1",
              Type="type1"
           },

           new Owner
           {
               Id=2,
              Name = "Veli",
              Surname="Öz",
              Date=new DateTime(2022,10,10),
              Explanition="Explanation2",
              Type="type2"
            },

            new Owner
            {
              Id=3,
              Name = "Ayşe",
              Surname="Öz",
              Date=new DateTime(2022,11,11),
              Explanition="Explanation3",
              Type="type3"
             },

            new Owner
            {
              Id=4,
              Name = "Fatma",
              Surname="Öz",
              Date=new DateTime(2022,12,12),
              Explanition="Explanation4",
              Type="type4"
             },

        };
        
        //-------------read-------------------
        [HttpGet]
        public IActionResult GetOwner()
        {
            var ownerList = OwnerList.OrderBy(x => x.Id).ToList<Owner>();
            return Ok(ownerList);
        }

        //----------create-------------------------
        [Route("create")]
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult AddOwner(Owner model)
        {
            var ownerList = new List<Owner>();
            ownerList.Add(model);
            if (ownerList.Any(e => e.Explanition.Contains("hack")))
                return NotFound();
            else
                return Ok(ownerList);

        }

        //---------------------update-----------------
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        [Route("update")]
        [HttpPut]
        public IActionResult UpdateOwner(int id, Owner owner)
        {
            if (id != owner.Id)
                return NotFound("Not Found");

            var ownerList = OwnerList.OrderBy(x => x.Id).ToList<Owner>();
            var update = ownerList.FirstOrDefault(x => x.Id == id);
            update.Name = owner.Name.ToUpper();
            update.Surname = owner.Surname.ToUpper();
            update.Date = owner.Date;
            update.Explanition= owner.Explanition;
            update.Type = owner.Type;
            return Ok(ownerList);
        }

        //-----------------delete-------------------------
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOwner(int id)
        {

            var ownerList = OwnerList.OrderBy(x => x.Id).ToList<Owner>();
            var owner = ownerList.FirstOrDefault(x => x.Id == id);
            if (owner == null)
                return NotFound("Owner Not Found");
            ownerList.Remove(owner);
            return Ok(ownerList);

        }

    }
}
