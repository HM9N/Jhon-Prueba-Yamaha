namespace FidelizacionBackend.Services
{
    public class SaleService : ISaleService
    {

        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SaleDTO>> GetSalesAsync()
        {
            IEnumerable<Sale> sales = await _saleRepository.GetSalesAsync();
            IEnumerable<SaleDTO> salesDTO = _mapper.Map<List<SaleDTO>>(sales);
            return salesDTO;
        }


        public async Task<bool> SaveSaleAsync(SaleDTO saleDTO)
        {
            var sale = _mapper.Map<Sale>(SaleDTO);

            return await _saleRepository.SaveSaleAsync(sale);
        }
    }
}
