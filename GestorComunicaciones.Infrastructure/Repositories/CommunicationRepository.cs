using GestorComunicaciones.Core.Entities;
using GestorComunicaciones.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace GestorComunicaciones.Infrastructure.Repositories
{
    public class CommunicationRepository : BaseRepository<Communication,long>
    {
        public CommunicationRepository(CommunicationContext context) : base(context)
        {

        }

        override public async Task Add(Communication entity)
        {
            var qwery = "exec InsertarComunicacion @Contenido, @Remitente, @Destinatario, @TipoCorrespondencia";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("Contenido", SqlDbType.VarChar) { Value = entity.Content },
                new SqlParameter("Remitente", SqlDbType.Int) { Value = entity.SenderId },
                new SqlParameter("Destinatario", SqlDbType.Int) { Value = entity.RecipientId },
                new SqlParameter("TipoCorrespondencia", SqlDbType.Int) { Value = entity.CommunicationTypeId }};
            await _context
                .Database
                .ExecuteSqlRawAsync(qwery, parameters);

        }

    }
}
