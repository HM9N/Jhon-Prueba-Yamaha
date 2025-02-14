import React, { useState, useEffect, useContext } from "react";
import SalesContext from "../context/SalesContext";

const initialForm = {
  id: null,
  numeroFactura: "",
  ciudad: "",
  tienda: "",
  precio: "",
  vendedor: "",
  cliente: "",
};

const FormSales = () => {
  const { createSale, updateSale, dataToEdit, vendedores, clientes } = useContext(SalesContext);
  const [form, setForm] = useState(initialForm);

  useEffect(() => {
    if (dataToEdit) {
      setForm(dataToEdit);
    } else {
      setForm(initialForm);
    }
  }, [dataToEdit]);

  const handleChange = (e) => {
    setForm({
      ...form,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!form.ciudad || !form.tienda || !form.precio || !form.numeroMotor || !form.modelo || !form.vendedor || !form.cliente) {
      alert("Datos incompletos");
      return;
    }

    if (form.id === null) {
      createSale(form);
    } else {
      updateSale(form);
    }

  };

  return (
    <div>
      <h3>{dataToEdit ? "Editar" : "Agregar"} Venta</h3>
      <form onSubmit={handleSubmit}>
        <input type="text" name="numeroFactura" placeholder="Número de Factura" onChange={handleChange} value={form.numeroFactura} />
        <input type="text" name="ciudad" placeholder="Ciudad" onChange={handleChange} value={form.ciudad} />
        <select name="tienda" onChange={handleChange} value={form.tienda}>
          <option value="">Selecciona Tienda</option>
          <option value="Tienda 1">Tienda 1</option>
          <option value="Tienda 2">Tienda 2</option>
        </select>
        <input type="number" name="precio" placeholder="Precio" onChange={handleChange} value={form.precio} />
        <input type="text" name="Vehiculo" placeholder="Busca el vehiculo" onChange={handleChange} />
        <select name="vendedor" onChange={handleChange} value={form.vendedor}>
          <option value="">Selecciona Vendedor</option>
          {vendedores.map((vendedor) => (
            <option key={vendedor.id} value={vendedor.id}>{vendedor.nombre}</option>
          ))}
        </select>
        <select name="cliente" onChange={handleChange} value={form.cliente}>
          <option value="">Selecciona Cliente</option>
          {clientes.map((cliente) => (
            <option key={cliente.id} value={cliente.id}>{cliente.nombre}</option>
          ))}
        </select>
        <input type="submit" value="Enviar" />
      </form>
    </div>
  );
};

export default FormSales;