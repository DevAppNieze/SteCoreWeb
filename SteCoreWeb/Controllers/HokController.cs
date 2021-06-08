using DataCore;
using DomainCore.Entites;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServiceCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteCoreWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HokController : ControllerBase
    {
        private readonly IClientService _ser;
        private readonly IConfiguration _config;

        public HokController(IConfiguration config, IClientService ser)
        {
            _config = config;
            _ser = ser;
        }
        
        [Route("GetAllClients")]
        public JsonResult Get()
        {
            return new JsonResult(_ser.getAllClient());
        }
        [HttpPost]
        public JsonResult Post(Client cc)
        {

            _ser.AddClient(cc);
            return new JsonResult("Client added");
        }
        [HttpPut]
        public JsonResult Put(Client cc)
        {
            Client up = _ser.findClientByID(cc.Id);            
            up.Nom = cc.Nom;
            up.Tel = cc.Tel;
            up.Adresse = cc.Adresse;
            up.Matricule = cc.Matricule;
            up.Code = cc.Code;
            up.CodeCat = cc.Code;
            up.EtbSec = cc.EtbSec;
            up.Mail = cc.Mail;
            _ser.editClient(up);
            return new JsonResult("Client updated");
        }
    }
}
