import React, { useContext } from "react";
import SalesContext from "../context/SalesContext";

const TableRowSales = ({ el }) => {
  const { setDataToEdit } = useContext(SalesContext);
  let { numeroFactura, ciudad, tienda, precio, numeroMotor, modelo, vendedor, cliente } = el;
  console.log(numeroFactura)
  return (
    <tr>
      <td>{numeroFactura}</td>
      <td>{ciudad}</td>
      <td>{tienda}</td>
      <td>{precio}</td>
      <td>{numeroMotor}</td>
      <td>{modelo}</td>
      <td>{vendedor}</td>
      <td>{cliente}</td>
      <td>
        <button onClick={() => setDataToEdit(el)}>Editar</button>
      </td>
    </tr>
  );
};

export default TableRowSales;