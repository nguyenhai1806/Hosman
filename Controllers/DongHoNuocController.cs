﻿using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hosman_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DongHoNuocController : ControllerBase
    {
        private readonly IDongHoNuocRepository _repo;
        public DongHoNuocController(IDongHoNuocRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                return Ok(_repo.GetAllItems());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{maBanGhi}")]
        public IActionResult GetItemByID(string maBanGhi)
        {
            //TODO Kiểm tra chỉ số sau >= chỉ số trước
            DongHoNuocModel item = _repo.GetItemByID(maBanGhi);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult PostNewItem(DongHoNuocModel newItem)
        {
            try
            {
                //TODO Kiểm tra chỉ số sau >= chỉ số trước
                newItem.MaBanGhi = Guid.NewGuid().ToString();
                return _repo.PostNewItem(newItem) ? Ok(newItem) : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{maBanGhi}")]
        public IActionResult PutItem(string maBanGhi, DongHoNuocModel updateItem)
        {
            if (maBanGhi != updateItem.MaBanGhi)
                return NotFound();
            return _repo.PutItem(updateItem) ? Ok() : BadRequest();
        }

        [HttpDelete("{maBanGhi}")]
        public IActionResult DeleteItem(string maBanGhi)
        {
            try
            {
                if (_repo.GetItemByID(maBanGhi) == null)
                    return NotFound();
                return _repo.RemoveItem(maBanGhi) ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
