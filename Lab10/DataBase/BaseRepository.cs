namespace Lab10.DataBase;

public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel
{
    private ApplicationContext Context { get; set; }

    public BaseRepository(ApplicationContext context)
    {
        Context = context;
        context.Database.EnsureCreated();
    }

    public TDbModel Create(TDbModel model)
    {
        Context.Set<TDbModel>().Add(model);
        Context.SaveChanges();
        return model;
    }

    public void Delete(Guid id)
    {
        var toDelete = Context.Set<TDbModel>().Find(id);
        if (toDelete != null)
        {
            Context.Set<TDbModel>().Remove(toDelete);
            Context.SaveChanges();
        }
    }

    public List<TDbModel> GetAll()
    {
        return Context.Set<TDbModel>().ToList();
    }

    public TDbModel Update(TDbModel model)
    {
        var toUpdate = Context.Set<TDbModel>().Find(model.Id);
        if (toUpdate != null)
        {
            Context.Entry(toUpdate).CurrentValues.SetValues(model);
            Context.SaveChanges();
        }
        return toUpdate;
    }

    public TDbModel Get(Guid id)
    {
        return Context.Set<TDbModel>().Find(id);
    }
}
