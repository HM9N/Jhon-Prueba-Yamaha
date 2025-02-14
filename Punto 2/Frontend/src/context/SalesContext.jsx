import { createContext, useEffect, useState } from "react";
import axios from "axios";

const SalesContext = createContext();

const SalesProvider = ({ children }) => {
  const [db, setDb] = useState([]);
  const [dataToEdit, setDataToEdit] = useState(null);
  const [vendedores, setVendedores] = useState([]);
  const [clientes, setClientes] = useState([]);
  
  const url = "http://localhost:5000/sale/getsales"; /* tomando como base el controlador que se usa en el backend (ver código en el repositorio) */


  useEffect(() => {
    axios.get(url)
      .then((res) => setDb(res.data))
      .catch(() => setDb(null));
  }, []);

  useEffect(() => {
    const getData = async () => {
      try {
        const resVendedores = await axios.get("http://localhost:5000/vendedor/getvendedores");
        const resClientes = await axios.get("http://localhost:5000/client/getclientes");
        setVendedores(resVendedores.data);
        setClientes(resClientes.data);
      } catch (error) {
        console.error("Error al obtener datos", error);
      }
    };

    getData();
  }, []);
 
  const createSale = async (data) => {
    data.id = Date.now();
    try {
      const res = await axios.post(url, data, {
        headers: { "Content-Type": "application/json" },
      });
      setDb([...db, res.data]);
    } catch (error) {
      console.error("Error al crear la venta", error);
    }
  };
  

  const updateSale = async (data) => {
    const endpoint = `${url}/${data.id}`;
    try {
      await axios.put(endpoint, data, {
        headers: { "Content-Type": "application/json" },
      });
      setDb(db.map((el) => (el.id === data.id ? data : el)));
    } catch (error) {
      console.error("Error al actualizar la venta", error);
    }
  };


  const data = {
    db,
    createSale,
    dataToEdit,
    setDataToEdit,
    updateSale,
    vendedores,
    clientes,
  };

  return <SalesContext.Provider value={data}>{children}</SalesContext.Provider>;
};

export { SalesProvider };
export default SalesContext;
