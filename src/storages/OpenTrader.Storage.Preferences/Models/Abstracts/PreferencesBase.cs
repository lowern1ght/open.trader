using System.ComponentModel.DataAnnotations;

namespace OpenTrader.Storage.Preferences.Models.Abstracts;

public class PreferencesBase
{
    [Key]
    public Guid Id { get; init; }
    
    [Required]
    public Guid UserId { get; init; }
}