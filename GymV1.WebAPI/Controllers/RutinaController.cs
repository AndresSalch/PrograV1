using GymV1.Share.Service;
using GymV1.Share.Model;
using Microsoft.AspNetCore.Mvc;

namespace GYMV1.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RutinaController : ControllerBase
	{
		string sqlconnection = "Data Source=68.168.208.58;" +
			"Initial Catalog=Progra5; Persist Security Info=True;" +
			"TrustServerCertificate=True; User ID=PrograV;" +
			"Password=Aqi90h7@9";

		[HttpGet]
		[Route("getRutina")]
		public async Task<ActionResult<List<cRutina>>> getRutinas()
		{
			try
			{
				dsRutina mdsRutina = new dsRutina(sqlconnection);
				List<cRutina> mLista = await mdsRutina.getServicelist();
				return Ok(mLista);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("getRutina/{idRutina}")]
		public async Task<ActionResult<cRutina>> getRutina(string idRutina)
		{
			try
			{
				dsRutina mdsRuti = new dsRutina(sqlconnection);
				cRutina mRutina = await mdsRuti.getServiceById(Convert.ToInt32(idRutina));
				if (mRutina == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(mRutina);
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("agregarRutina")]
		public async Task<ActionResult<string>> AgregarRuti(cRutinaDTO rutina)
		{
			try
			{
				dsRutina mdsRuti = new dsRutina(sqlconnection);
				if (await mdsRuti.addService(rutina) == 1)
				{
					return Ok("Ok");
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
		[Route("actualizarRutina")]
		public async Task<ActionResult<string>> ActualizarRuti(cRutina rutina)
		{
			try
			{
				dsRutina mdsRuti = new dsRutina(sqlconnection);
				if (await mdsRuti.updateService(rutina) == 1)
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
		[Route("borrarRutina")]
		public async Task<ActionResult<string>> BorrarRuti(cRutina rutina)
		{
			try
			{
				dsRutina mdsRuti = new dsRutina(sqlconnection);
				if (await mdsRuti.deleteService(rutina) == 1)
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

