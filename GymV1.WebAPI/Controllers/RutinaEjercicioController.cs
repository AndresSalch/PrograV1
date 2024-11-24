using GymV1.Share.Service;
using GymV1.Share.Model;
using Microsoft.AspNetCore.Mvc;

namespace GYMV1.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RutinaEjercicioController : ControllerBase
	{
		string sqlconnection = "Data Source=68.168.208.58;" +
			"Initial Catalog=Progra5; Persist Security Info=True;" +
			"TrustServerCertificate=True; User ID=PrograV;" +
			"Password=Aqi90h7@9";

		[HttpGet]
		[Route("getRutinaEjercicio")]
		public async Task<ActionResult<List<cRutinaEjercicio>>> getRutinaEjercicios()
		{
			try
			{
				dsRutinaEjercicio mdsRutinaEjercicio = new dsRutinaEjercicio(sqlconnection);
				List<cRutinaEjercicio> mLista = await mdsRutinaEjercicio.getServicelist();
				return Ok(mLista);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("getRutinaEjercicio/{idRutina}")]
		public async Task<ActionResult<cRutinaEjercicio>> getRutinaEjercicio(string idRutina)
		{
			try
			{
				dsRutinaEjercicio mdsRutinaEjercicio = new dsRutinaEjercicio(sqlconnection);
				cRutinaEjercicio mRutinaEjercicio = await mdsRutinaEjercicio.getServiceById(Convert.ToInt32(idRutina));
				if (mRutinaEjercicio == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(mRutinaEjercicio);
				}
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("agregarRutinaEjercicio")]
		public async Task<ActionResult<string>> AgregarRutinaEjercicio(cRutinaEjercicio rutinaEjercicio)
		{
			try
			{
				dsRutinaEjercicio mdsRutinaEjercicio = new dsRutinaEjercicio(sqlconnection);
				if (await mdsRutinaEjercicio.addService(rutinaEjercicio) == 1)
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


		[HttpDelete]
		[Route("borrarRutinaEjercicio")]
		public async Task<ActionResult<string>> BorrarRutinaEjercicio(cRutinaEjercicio rutinaEjercicio)
		{
			try
			{
				dsRutinaEjercicio mdsRutinaEjercicio = new dsRutinaEjercicio(sqlconnection);
				if (await mdsRutinaEjercicio.deleteService(rutinaEjercicio) == 1)
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

