import React from "react";
import { SalesProvider } from "../context/SalesContext";
import SalesForm from "./SalesForm";
import SalesTable from "./SalesTable";

const PruebaYamaha = () => {
  return (
    <SalesProvider>
      <div>
      <h2>Ventas</h2>
      <article>
        <SalesForm/>
        <hr></hr>
        <SalesTable />
      </article>
    </div>
    </SalesProvider>
  );
};

export default PruebaYamaha;
