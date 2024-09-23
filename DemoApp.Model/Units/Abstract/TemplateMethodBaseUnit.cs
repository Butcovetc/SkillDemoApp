namespace DemoApp.Model.Units.Abstract
{
    /// <summary>
    /// Base template method unit. Methoda firing order Init -> Proceed -> CleanUp
    /// </summary>
    public abstract class TemplateMethodBaseUnit 
    {
        /// <summary>
        /// Invoke first. Befor Proceed
        /// </summary>
        protected virtual void Init() { }

        /// <summary>
        /// Invokes second
        /// </summary>
        protected virtual void Proceed() { }

        /// <summary>
        /// Invokes last one. 
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

            catch (Exception)
            {
                throw;
            }

            finally
            {

            }
        }
    }
}
