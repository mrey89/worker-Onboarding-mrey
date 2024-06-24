using System;

namespace workerOnBording.Domain.Common;

public record struct AuditableEntity(DateTime Created, string CreatedBy, DateTime? LastModified, string LastModifiedBy) { }