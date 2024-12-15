using TallerFinal.DTO.CONF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TallerFinal.DAL.CONF
{
    public class ParticipacionDAL
    {
        private readonly ParticipacionDbContext _context;

        public ParticipacionDAL()
        {
            _context = new ParticipacionDbContext();
        }

        // Obtener todas las participaciones
        public List<Participacion> ObtenerParticipaciones()
        {
            return _context.Participaciones
                .Include(p => p.IdConferenciaNavigation)  // Incluir Conferencia relacionada
                .Include(p => p.IdParticipanteNavigation) // Incluir Participante relacionado
                .Select(p => new Participacion
                {
                    IdParticipacion = p.IdParticipacion,
                    IdParticipante = p.IdParticipante,
                    IdConferencia = p.IdConferencia,
                    Sesion = p.Sesion,
                    FechaCreacion = p.FechaCreacion,
                    UsuarioCrea = p.UsuarioCrea,
                    FechaModificacion = p.FechaModificacion,
                    UsuarioModifica = p.UsuarioModifica,
                    Estado = p.Estado
                })
                .ToList();
        }

        // Obtener participaciones con un filtro
        public List<Participacion> ObtenerParticipacionesConFiltro(string filtro)
        {
            return _context.Participaciones
                .Where(p => p.Sesion.Contains(filtro) || p.IdConferenciaNavigation.Titulo.Contains(filtro))
                .Include(p => p.IdConferenciaNavigation)
                .Include(p => p.IdParticipanteNavigation)
                .ToList();
        }

        // Insertar una nueva participación
        public void InsertarParticipacion(Participacion participacion)
        {
            _context.Participaciones.Add(participacion);
            _context.SaveChanges();
        }

        // Obtener una participación por ID
        public Participacion ObtenerParticipacionPorId(int id)
        {
            var participacion = _context.Participaciones
                .Include(p => p.IdConferenciaNavigation)
                .Include(p => p.IdParticipanteNavigation)
                .FirstOrDefault(p => p.IdParticipacion == id);

            if (participacion == null)
            {
                throw new Exception($"No se encontró ninguna participación con el ID {id}");
            }

            return participacion;
        }

        // Actualizar una participación
        public void ActualizarParticipacion(Participacion participacion)
        {
            var entidadExistente = _context.Participaciones
                .FirstOrDefault(p => p.IdParticipacion == participacion.IdParticipacion);

            if (entidadExistente != null)
            {
                // Preservar relaciones importantes
                participacion.IdConferenciaNavigation = entidadExistente.IdConferenciaNavigation;
                participacion.IdParticipanteNavigation = entidadExistente.IdParticipanteNavigation;

                // Desadjuntar la entidad existente
                _context.Entry(entidadExistente).State = EntityState.Detached;
            }

            _context.Entry(participacion).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Eliminar una participación
        public void EliminarParticipacion(int id)
        {
            var participacion = _context.Participaciones
                .FirstOrDefault(p => p.IdParticipacion == id);

            if (participacion != null)
            {
                _context.Participaciones.Remove(participacion);
                _context.SaveChanges();
            }
        }
    }
}
