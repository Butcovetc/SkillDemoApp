using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;

namespace DemoApp.Model.Units.Abstract
{
    /// <summary>
    /// Base template method unit. Methoda firing order Init -> Proceed -> CleanUp
    /// </summary>
    internal abstract class TemplateMethodBaseUnit 
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Databnase context</param>
        public TemplateMethodBaseUnit(ILogger logger, DataBaseContext context)
        {
            Context = context;
            Logger = logger;
        }

        /// <summary>
        /// Logger
        /// </summary>
        protected ILogger Logger { get; private set; }

        /// <summary>
        /// Context
        /// </summary>
        protected DataBaseContext Context { get; private set; }

        /// <summary>
        /// Invoke first. Befor Proceed
        /// </summary>
        protected virtual void Init() { }

        /// <summary>
        /// Invokes second
        /// </summary>
        protected virtual void Proceed() { }

        /// <summary>
        /// Invokes after procced. 
        /// </summary>
        protected virtual void CleanUp() { }


        /// <summary>
        /// Main operation that describes rule of execution
        /// </summary>
        public void Execute()
        {
            try
            {
                Init();

                Proceed();

                CleanUp();
            }

            catch (Exception ex)
            {
                Logger.LogError(exception: ex,ex.Message);

                throw;
            }

            finally
            {

            }
        }
    }
}
