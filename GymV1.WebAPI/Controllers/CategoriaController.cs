using GymV1.Share.Service;
using GymV1.Share.Model;
using Microsoft.AspNetCore.Mvc;
namespace GYMV1.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriaController : ControllerBase
	{
		string sqlconnection = "Data Source=68.168.208.58;" +
			"Initial Catalog=Progra5; Persist Security Info=True;" +
			"TrustServerCertificate=True; User ID=PrograV;" +
			"Password=Aqi90h7@9";
		[HttpGet]
		[Route("getCategorias")]
		public async Task<ActionResult<List<cCategoria>>> getCategoria()
		{
			try
			{
				dsCategoria mdsCat = new dsCategoria(sqlconnection);
				List<cCategoria> mLista = await mdsCat.getServicelist();
				return Ok(mLista);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
		[HttpGet]
		[Route("getCategoria/{idCategoria}")]
		public async Task<ActionResult<cCategoria>> getCategoria(string idCategoria)
		{
			try
			{
				dsCategoria mdsCat = new dsCategoria(sqlconnection);
				cCategoria mCategoria = await mdsCat.getServiceById(Convert.ToInt32(idCategoria));
				if (mCategoria == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(mCategoria);
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
		[HttpPost]
		[Route("agregarCategoria")]

		public async Task<ActionResult<string>> AgregarCat(cCategoriaDTO categoria)
		{
			try
			{
				dsCategoria mdsCat = new dsCategoria(sqlconnection);
				if (await mdsCat.addService(categoria) == 1)
				{
					return Ok("OK");
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
		[HttpPut]
		[Route("actualizarCategoria")]
		public async Task<ActionResult<string>> ActualizaCat(cCategoria categoria)
		{
			try
			{
				dsCategoria mdsCat = new dsCategoria(sqlconnection);
				if (await mdsCat.updateService(categoria) == 1)
				{
					return Ok("OK");
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		[Route("borrarCategoria")]
		public async Task<ActionResult<string>> BorrarCat(cCategoria categoria)
		{
			try
			{
				dsCategoria mdsCat = new dsCategoria(sqlconnection);
				if (await mdsCat.deleteService(categoria) == 1)
				{
					return Ok("OK");
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
