﻿namespace Genocs.Integration.CognitiveServices.Contracts;

/// <summary>
/// The Form Extractor Response.
/// </summary>
public class FormExtractorResponse
{
    /// <summary>
    /// The request id.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// The context id.
    /// </summary>
    public string? ContextId { get; set; }

    /// <summary>
    /// The processed resource url.
    /// </summary>
    public string ResourceUrl { get; set; } = default!;

    /// <summary>
    /// The classification object.
    /// </summary>
    public Classification? Classification { get; set; }

    /// <summary>
    /// The dynamic data about the results.
    /// </summary>
    public List<dynamic>? ContentData { get; set; }
}
