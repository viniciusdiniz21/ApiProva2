using AutoMapper;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using Revisao.Data.Providers.MongoDb.Collections;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Repositories
{
    public class RegistroJogoRepository : IRegistroJogoRepository
    {
        private readonly IMongoRepository<RegistroJogoCollection> _registroJogoRepository;
        private readonly IMapper _mapper;

        public RegistroJogoRepository(IMongoRepository<RegistroJogoCollection> registroJogoRepository,
            IMapper mapper
            )
        {
            _registroJogoRepository = registroJogoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistroJogo>> ObterTodosOsJogos()
        {
            var listaDeJogos = _registroJogoRepository.FilterBy(filtro => true);

            return _mapper.Map<IEnumerable<RegistroJogo>>(listaDeJogos);
        }

        public async Task RegistrarJogo(RegistroJogo registroJogo)
        {
            var novoRegistroJogoCollection = _mapper.Map<RegistroJogoCollection>(registroJogo);
            await _registroJogoRepository.InsertOneAsync(novoRegistroJogoCollection);
        }
    }
}
