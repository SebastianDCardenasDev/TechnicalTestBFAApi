namespace Application.Const
{
    public static class ApplicationConst
    {
        #region Status
        public const bool Ok = true;
        public const bool Bad = false;
        #endregion

        #region Messages DB
        public const string Empty = "";

        // Regions
        public const string RegionsDuplicated = "La región ya está registrada.";
        public const string RegionsSuccess = "Región creada con éxito.";
        public const string RegionsNotFound = "Regiones no encontradas.";
        public const string RegionsNotData = "No se encontraron datos de la región.";
        public const string RegionsUpdate = "La región fue actualizada correctamente.";
        public const string RegionsDelete = "La región fue eliminada correctamente.";
       
        #endregion
    }
}
