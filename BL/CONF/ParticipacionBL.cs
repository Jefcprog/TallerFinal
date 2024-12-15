using System;
using System.Collections.Generic;
using System.Linq;
using TallerFinal.DAL.CONF;
using TallerFinal.DTO.CONF;

namespace MATRICULA.BL.INV
{
    public class ParticipacionBL
    {
        private readonly ParticipacionesDAL _participacionesDAL;

        public ParticipacionBL()
        {
            _participacionesDAL = new ParticipacionesDAL();
        }

        // Obtener todas las participaciones
        public List<Participacion> ObtenerParticipaciones()
        {
            return _participacionesDAL.ObtenerParticipaciones();
        }

        // Obtener participaciones con un filtro
        public List<Participacion> ObtenerParticipacionesConFiltro(string filtro)
        {
            return _participacionesDAL.ObtenerParticipacionesConFiltro(filtro);
        }

        // Guardar una nueva participación
        public void GuardarParticipacion(int idParticipante, int idConferencia, string sesion, string usuarioCrea)
        {
            var participacion = new Participacion
            {
                IdParticipante = idParticipante,
                IdConferencia = idConferencia,
                Sesion = sesion,
                UsuarioCrea = usuarioCrea,
                FechaCreacion = DateTime.Now
            };
            _participacionesDAL.InsertarParticipacion(participacion);
        }

        // Obtener una participación por ID
        public Participacion ObtenerParticipacionPorId(int id)
        {
            return _participacionesDAL.ObtenerParticipacionPorId(id);
        }

        // Actualizar una participación existente
        public void ActualizarParticipacion(Participacion participacion)
        {
            _participacionesDAL.ActualizarParticipacion(participacion);
        }

        // Eliminar una participación
        public void EliminarParticipacion(int id)
        {
            _participacionesDAL.EliminarParticipacion(id);
        }
    }
}
