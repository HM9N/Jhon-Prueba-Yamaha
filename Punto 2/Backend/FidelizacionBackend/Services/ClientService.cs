using FidelizacionBackend.Repositories;

namespace FidelizacionBackend.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDTO>> GetClientsAsync()
        {
            IEnumerable<Client> clients = await _clientRepository.GetClientsAsync();
            IEnumerable<ClientDTO> clientsDTO = _mapper.Map<List<ClientDTO>>(clients);
            return clientsDTO;
        }


        public async Task<bool> SaveClientAsync(ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(ClientDTO);

            return await _clientRepository.SaveClientAsync(client);
        }
    }
}
