import React, { useContext } from "react";
import SalesTableRow from "./SalesTableRow";
import SalesContext from "../context/SalesContext";

const TableSales = () => {
  const { db } = useContext(SalesContext);
  return (
    <div>
      <h3>Lista de Ventas</h3>
      <table>
        <thead>
          <tr>
            <th>NumeroFactura</th>
            <th>Ciudad</th>
            <th>Tienda</th>
            <th>Precio</th>
            <th>NumeroMotor</th>
            <th>Modelo</th>
            <th>Vendedor</th>
            <th>Cliente</th>
          </tr>
        </thead>
        <tbody>
          {db.length > 0 ? (
            db.map((el) => (
              <SalesTableRow
                key={el.id}
                el={el}
              />
            ))
          ) : (
            <tr>
              <td>Sin datos</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default TableSales;
