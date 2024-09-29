﻿using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICountriesController
    {
        Task<ActionResult<IEnumerable<CountriesDto>>> GetAll();
        Task<IActionResult> Delete(int id);
        Task<ActionResult<Countries>> Save([FromBody] CountriesDto countriesDto);
        Task<IActionResult> Update([FromBody] CountriesDto countriesDto);
    }
}