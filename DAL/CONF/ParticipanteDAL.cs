using TallerFinal.DTO.CONF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TallerFinal.DAL.CONF
{
    public class ParticipantesDAL
    {
        private readonly ParticipanteDbContext _context;

        public ParticipantesDAL()
        {
            _context = new ParticipanteDbContext();
        }

        // Obtener todos los participantes
        public List<Participante> ObtenerParticipantes()
        {
            return _context.Participantes
                .Select(p => new Participante
                {
                    IdParticipante = p.IdParticipante,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Compania = p.Compania,
                    Telefono = p.Telefono,
                    Email = p.Email,
                    Domicilio = p.Domicilio,
                    CallesTransversales = p.CallesTransversales,
                    Ciudad = p.Ciudad,
                    Region = p.Region,
                    CodigoPostal = p.CodigoPostal,
                    Pais = p.Pais
                })
                .ToList();
        }

        // Obtener participantes con un filtro
        public List<Participante> ObtenerParticipantesConFiltro(string filtro)
        {
            return _context.Participantes
                .Where(p => p.Nombre.Contains(filtro) || p.Apellido.Contains(filtro) || p.Email.Contains(filtro))
                .ToList();
        }

        // Insertar un nuevo participante
        public void InsertarParticipante(Participante participante)
        {
            _context.Participantes.Add(participante);
            _context.SaveChanges();
        }

        // Obtener un participante por ID
        public Participante ObtenerParticipantePorId(int id)
        {
            var participante = _context.Participantes.FirstOrDefault(p => p.IdParticipante == id);

            if (participante == null)
            {
                throw new Exception($"No se encontró ningún participante con el ID {id}");
            }

            return participante;
        }

        // Actualizar un participante
        public void ActualizarParticipante(Participante participante)
        {
            var entidadExistente = _context.Participantes.FirstOrDefault(p => p.IdParticipante == participante.IdParticipante);

            if (entidadExistente != null)
            {
                // Preservar relaciones existentes si aplica
                participante.Participacions = entidadExistente.Participacions;

                // Desadjuntar la entidad existente
                _context.Entry(entidadExistente).State = EntityState.Detached;
            }

            _context.Entry(participante).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Eliminar un participante
        public void EliminarParticipante(int id)
        {
            var participante = _context.Participantes.FirstOrDefault(p => p.IdParticipante == id);

            if (participante != null)
            {
                _context.Participantes.Remove(participante);
                _context.SaveChanges();
            }
        }
    }
}
