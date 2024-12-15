using TallerFinal.DAL.CONF;
using TallerFinal.DTO.CONF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TallerFinal.BL.CONF
{
    public class ParticipantesBL
    {
        private readonly ParticipantesDAL _participantesDAL;

        public ParticipantesBL()
        {
            _participantesDAL = new ParticipantesDAL();
        }

        public List<Participante> ObtenerParticipantes()
        {
            return _participantesDAL.ObtenerParticipantes();
        }

        public List<Participante> ObtenerParticipantesConFiltro(string filtro)
        {
            return _participantesDAL.ObtenerParticipantesConFiltro(filtro);
        }

        public void GuardarParticipante(string nombre, string apellido, string? compania, string? telefono, string email, string? domicilio, string? callesTransversales, string? ciudad, string? region, string? codigoPostal, string? pais)
        {
            var participante = new Participante
            {
                Nombre = nombre,
                Apellido = apellido,
                Compania = compania,
                Telefono = telefono,
                Email = email,
                Domicilio = domicilio,
                CallesTransversales = callesTransversales,
                Ciudad = ciudad,
                Region = region,
                CodigoPostal = codigoPostal,
                Pais = pais
            };
            _participantesDAL.InsertarParticipante(participante);
        }

        public Participante ObtenerParticipantePorId(int id)
        {
            return _participantesDAL.ObtenerParticipantePorId(id);
        }

        public void ActualizarParticipante(Participante participante)
        {
            _participantesDAL.ActualizarParticipante(participante);
        }

        public void EliminarParticipante(int id)
        {
            _participantesDAL.EliminarParticipante(id);
        }
    }
}
