using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Services;
using sahilNameSorterWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace sahilNameSorterWeb.Controllers
{

 [Route("api/[controller]")]
public class GenderController : Controller
{
    private readonly IGenderizeClient _genderizeClient;

    public GenderController(IGenderizeClient genderizeClient)
    {
        _genderizeClient = genderizeClient;
    }

    [HttpGet]
    public async Task<IEnumerable<string>> Get()
    {
        return await _genderizeClient.GetGender();
    }
}
}
