using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface ITipoIdentificacionService
    {
        Task<DBEntity> Create(TipoIdentificacionEntity entity);
        Task<DBEntity> Delete(TipoIdentificacionEntity entity);
        Task<IEnumerable<TipoIdentificacionEntity>> Get();
        Task<TipoIdentificacionEntity> GetById(TipoIdentificacionEntity entity);
        Task<DBEntity> Update(TipoIdentificacionEntity entity);
    }

    public class TipoIdentificacionService : ITipoIdentificacionService
    {
        private readonly IDataAccess sql;

        public TipoIdentificacionService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud

        //Metodo Get

        public async Task<IEnumerable<TipoIdentificacionEntity>> Get()

        {

            try
            {

                var result = sql.QueryAsync<TipoIdentificacionEntity>(sp: "dbo.TipoIdentificacion_Obtener");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo GetById

        public async Task<TipoIdentificacionEntity> GetById(TipoIdentificacionEntity entity)

        {

            try
            {

                var result = sql.QueryFirstAsync<TipoIdentificacionEntity>(sp: "dbo.TipoIdentificacion_Obtener", Param: new
                {
                    entity.IdTipoIdentificacion
                });

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo Create

        public async Task<DBEntity> Create(TipoIdentificacionEntity entity)

        {

            try
            {

                var result = sql.ExecuteAsync(sp: "exp.TipoIdentificacion_Insertar", Param: new
                {
                    entity.Descripcion
                });

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo Update

        public async Task<DBEntity> Update(TipoIdentificacionEntity entity)

        {

            try
            {

                var result = sql.ExecuteAsync(sp: "exp.TipoIdentificacionActualizar", Param: new
                {
                    entity.IdTipoIdentificacion,
                    entity.Descripcion
                });

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo Delete

        public async Task<DBEntity> Delete(TipoIdentificacionEntity entity)

        {

            try
            {

                var result = sql.ExecuteAsync(sp: "dbo.TipoIdentificacion_Eliminar", Param: new
                {
                    entity.IdTipoIdentificacion
                });

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }

        Task<TipoIdentificacionEntity> ITipoIdentificacionService.GetById(TipoIdentificacionEntity entity)
        {
            throw new NotImplementedException();
        }





        #endregion


    }
}