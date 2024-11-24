using GymV1.Share.Service;
using GymV1.Share.Model;
using Microsoft.AspNetCore.Mvc;

namespace GYMV1.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EjercicioController : ControllerBase
	{
		string sqlconnection = "Data Source=68.168.208.58;" +
			"Initial Catalog=Progra5; Persist Security Info=True;" +
			"TrustServerCertificate=True; User ID=PrograV;" +
			"Password=Aqi90h7@9";
		[HttpGet]
		[Route("getEjercicios")]
		public async Task<ActionResult<List<cEjercicio>>> getEjercicio()
		{
			try
			{
				dsEjercicio mdsEjer = new dsEjercicio(sqlconnection);
				List<cEjercicio> mLista = await mdsEjer.getServicelist();
				return Ok(mLista);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
		[HttpGet]
		[Route("getEjercicio/{idEjercicio}")]
		public async Task<ActionResult<cEjercicio>> getEjercicio(string idEjercicio)
		{
			try
			{
				dsEjercicio mdsEjer = new dsEjercicio(sqlconnection);
				cEjercicio mEjercicio = await mdsEjer.getServiceById(Convert.ToInt32(idEjercicio));
				if (mEjercicio == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(mEjercicio);
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
		[HttpPost]
		[Route("agregarEjercicio")]

		public async Task<ActionResult<string>> AgregarEjer(cEjercicioDTO ejercicio)
		{
			try
			{
				dsEjercicio mdsEjer = new dsEjercicio(sqlconnection);
				if (await mdsEjer.addService(ejercicio) == 1)
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
		[Route("actualizaEjercicio")]
		public async Task<ActionResult<string>> ActualizaEjer(cEjercicio ejercicio)
		{
			try
			{
				dsEjercicio mdsEjer = new dsEjercicio(sqlconnection);
				if (await mdsEjer.updateService(ejercicio) == 1)
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
		[Route("borrarEjercicio")]
		public async Task<ActionResult<string>> BorrarEjer(cEjercicio ejercicio)
		{
			try
			{
				dsEjercicio mdsEjer = new dsEjercicio(sqlconnection);
				if (await mdsEjer.deleteService(ejercicio) == 1)
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

