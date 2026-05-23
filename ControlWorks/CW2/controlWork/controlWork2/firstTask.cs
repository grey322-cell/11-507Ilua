namespace superProject;

using System.Reflection;

[AttributeUsage(AttributeTargets.Property)]
public class Sensitive : Attribute { }
class AttributeFilter
{
    public static List<object> GetValidObjects(List<object> objects)
    {
        List<object> result = null;
        foreach (object obj in objects)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                Attribute a = prop.GetCustomAttribute<Sensitive>();
                if (a != null)
                {
                    result.Add(obj);
                }
            }
        }

        return result;
    }
}