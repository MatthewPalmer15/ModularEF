using Modular.Core.Models.Sequence;
using Modular.Core.Services.Repositories.Abstract.Misc;
using Modular.Core.Services.Repositories.Abstract.Sequence;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class SequenceRespository : ISequenceRepository
    {

        #region "  Constructors  "

        public SequenceRespository(ModularDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Sequence> All()
        {
            var query = from sequence in _context.Sequences select sequence;
            return query;
        }

        public int GetNewValue(string sequenceName)
        {
            int newValue = 0;

            var query = All();
            query = query.Where(sequence => sequence.Name.Trim().ToUpper() == sequenceName.Trim().ToUpper());

            Sequence? sequence = query.SingleOrDefault();

            if (sequence !=  null)
            {
                newValue = sequence.Count;
                sequence.Count += 1;

                _context.SaveChangesAsync();
            }

            return newValue;
        }

        
        public void Add(Sequence sequence)
        {
            _context.Sequences.Add(sequence);
        }

        public void Update(Sequence sequence)
        {
            sequence.Update();
            _context.Sequences.Update(sequence);
        }

        public void Delete(Sequence sequence)
        {
            _context.Sequences.Remove(sequence);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }


        #endregion


    }
}
