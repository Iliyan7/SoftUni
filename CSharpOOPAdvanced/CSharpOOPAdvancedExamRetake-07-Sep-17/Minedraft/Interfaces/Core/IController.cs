using System.Collections.Generic;

public interface IController
{
    string Register(IList<string> args);

    IReadOnlyCollection<IEntity> Entities { get; }

    string Produce();
}