using TallerFinal.DTO.CONF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TallerFinal.DAL.CONF
{
    public class ConferenciasDAL
    {
        private readonly ConferenciaDbContext _context;

        public ConferenciasDAL()
        {
            _context = new ConferenciaDbContext();
        }

        // Obtener todas las conferencias
        public List<Conferencia> ObtenerConferencias()
        {
            return _context.Conferencias
                .Select(c => new Conferencia
                {
                    IdConferencia = c.IdConferencia,
                    Titulo = c.Titulo,
                    Fecha = c.Fecha,
                    Lugar = c.Lugar
                })
                .ToList();
        }

        // Obtener conferencias con un filtro
        public List<Conferencia> ObtenerConferenciasConFiltro(string filtro)
        {
            return _context.Conferencias
                .Where(c => c.Titulo.Contains(filtro) || c.Lugar.Contains(filtro))
                .ToList();
        }

        // Insertar una nueva conferencia
        public void InsertarConferencia(Conferencia conferencia)
        {
            _context.Conferencias.Add(conferencia);
            _context.SaveChanges();
        }

        // Obtener una conferencia por ID
        public Conferencia ObtenerConferenciaPorId(int id)
        {
            var conferencia = _context.Conferencias.FirstOrDefault(c => c.IdConferencia == id);

            if (conferencia == null)
            {
                throw new Exception($"No se encontró ninguna conferencia con el ID {id}");
            }

            return conferencia;
        }

        // Actualizar una conferencia
        public void ActualizarConferencia(Conferencia conferencia)
        {
            var entidadExistente = _context.Conferencias.FirstOrDefault(c => c.IdConferencia == conferencia.IdConferencia);

            if (entidadExistente != null)
            {
                // Preservar campos importantes si es necesario
                conferencia.Participacions = entidadExistente.Participacions;

                // Desadjuntar la entidad existente
                _context.Entry(entidadExistente).State = EntityState.Detached;
            }

            _context.Entry(conferencia).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Eliminar una conferencia
        public void EliminarConferencia(int id)
        {
            var conferencia = _context.Conferencias.FirstOrDefault(c => c.IdConferencia == id);

            if (conferencia != null)
            {
                _context.Conferencias.Remove(conferencia);
                _context.SaveChanges();
            }
        }
    }
}
