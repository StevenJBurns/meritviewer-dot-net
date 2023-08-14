using System.Diagnostics;
using System.ComponentModel;

namespace MeritViewer.Domain.Primitive;

// Should this live in the Presentation layers?
public abstract class ObservableObject : INotifyPropertyChanged
	{
	public event PropertyChangedEventHandler? PropertyChanged;

	public virtual void RaisePropertyChanged(string propertyName)
		{
		this.VerifyPropertyName(propertyName);
		OnPropertyChanged(propertyName);
		}
		
	protected virtual void OnPropertyChanged(string propertyName)
		{
		this.VerifyPropertyName(propertyName);
		
		PropertyChangedEventHandler handler = this.PropertyChanged;
		
		if (handler != null)
			{
			var e = new PropertyChangedEventArgs(propertyName);
			handler(this, e);
			}
		}

	#region Debugging Aides

/// <summary>
/// Warns the developer if this object does not have
/// a public property with the specified name. This
/// method does not exist in a Release build.
/// </summary>
[Conditional("DEBUG")]
[DebuggerStepThrough]
public virtual void VerifyPropertyName(string propertyName)
{
	// Verify that the property name matches a real,
	// public, instance property on this object.
	if (TypeDescriptor.GetProperties(this)[propertyName] == null)
	{
		string msg = "Invalid property name: " + propertyName;

		if (this.ThrowOnInvalidPropertyName)
			throw new Exception(msg);
		else
			Debug.Fail(msg);
	}
}

/// <summary>
/// Returns whether an exception is thrown, or if a Debug.Fail() is used
/// when an invalid property name is passed to the VerifyPropertyName method.
/// The default value is false, but subclasses used by unit tests might
/// override this property's getter to return true.
/// </summary>
protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

#endregion // Debugging Aides
	}
