using Autodesk.Revit.DB;

namespace Number;

/// <summary>
/// Helper class used to work with parameters
/// </summary>
/// <remarks></remarks>
public class ParameterHelper
{
    private Parameter _parameter;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="p"></param>
    /// <remarks></remarks>
    public ParameterHelper(Parameter p)
    {

        // Widen Scope
        _parameter = p;
    }

    /// <summary>
    /// The parameter reference
    /// </summary>
    /// <value></value>
    /// <returns>Parameter Object</returns>
    /// <remarks></remarks>
    public Parameter ParameterObject
    {
        get
        {
            return _parameter;
        }
    }

    /// <summary>
    /// Returns value of the parameter
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public string Value
    {
        get
        {
            try
            {
                string v = GetValue(false);
                if (!string.IsNullOrEmpty(v))
                {
                    return v;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return null;
            }
        }

        set
        {
            try
            {
                SetValue(value, false);
            }
            catch
            {
            }
        }
    }

    /// <summary>
    /// Returns value of the parameter
    /// as a string
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public string ValueString
    {
        get
        {
            try
            {
                string v = GetValue(true);
                if (!string.IsNullOrEmpty(v))
                {
                    return v;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return null;
            }
        }

        set
        {
            try
            {
                SetValue(value, true);
            }
            catch
            {
            }
        }
    }

    /// <summary>
    /// Set a value to a parameter
    /// </summary>
    /// <param name="value">
    /// Value does not have to be a string
    /// </param>
    /// <param name="asString">As string?</param>
    /// <remarks></remarks>
    private void SetValue(object value, bool asString)
    {

        // Cannot edit readonly
        if (_parameter.IsReadOnly)
            return;

        try
        {
            // Storage Type
            switch (_parameter.StorageType)
            {
                case StorageType.Double:
                {
                    if (asString == true)
                    {
                        _parameter.SetValueString(value as string);
                    }
                    else
                    {
                        _parameter.Set((ElementId)value);
                    }

                    break;
                }

                case StorageType.ElementId:
                {
                    ElementId m_eid;
                    m_eid = (ElementId)value;
                    _parameter.Set(m_eid);
                    break;
                }

                case StorageType.Integer:
                {
                    _parameter.SetValueString(value as string);
                    break;
                }

                case StorageType.None:
                {
                    _parameter.SetValueString(value as string);
                    break;
                }

                case StorageType.String:
                {
                    _parameter.Set(value as string);
                    break;
                }
            }
        }
        catch
        {
        }
    }

    /// <summary>
    /// Get the value of a parameter
    /// </summary>
    /// <param name="asString">Return as String?</param>
    /// <returns>String representing the value</returns>
    /// <remarks></remarks>
    private string GetValue(bool asString)
    {

        // Return the Value
        switch (_parameter.StorageType)
        {
            case StorageType.Double:
            {
                if (asString == true)
                {
                    return _parameter.AsValueString();
                }
                else
                {
                    return _parameter.AsDouble().ToString();
                }
            }

            case StorageType.ElementId:
            {
                if (asString == true)
                {
                    // Get the Element's Name
                    var m_eid = new ElementId(_parameter.AsElementId().IntegerValue);
                    Element m_obj;
                    m_obj = _parameter.Element.Document.GetElement(m_eid);
                    return m_obj.Name;
                }
                else
                {
                    return _parameter.AsElementId().ToString();
                }
            }

            case StorageType.Integer:
            {
                return _parameter.AsInteger().ToString();
            }

            case StorageType.None:
            {
                return _parameter.AsValueString();
            }

            case StorageType.String:
            {
                return _parameter.AsString();
            }

            default:
            {
                return "";
            }
        }
    }
}
