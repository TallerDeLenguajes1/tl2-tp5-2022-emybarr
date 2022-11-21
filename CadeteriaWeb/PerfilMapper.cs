using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper; 
using CadeteriaWeb.Models;
using CadeteriaWeb.Models.ViewModels;
using Microsoft.Extensions.Configuration ;


namespace CadeteriaWeb
{
   public class PerfilMapper : Profile
   {

    public PerfilMapper()
    {
        CreateMap<Cadete,CadeteViewModel>().ReverseMap();

     
    }

   }

}