namespace WebApi.DataSource
{
    public class DatasourceResource: Attribute
    {
        public DatasourceResource(string resourceName)
        {
            ResourceName = resourceName;
        }

        public string ResourceName { get; set; }


    }
}
