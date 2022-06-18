import React, { useState } from "react";
import { Factura } from "../models";


export interface IFacturacionContext {
    facturas: Factura[];
}

export const FacturacionContext = React.createContext<IFacturacionContext>({ facturas: [] });

export const Facturacion = ({ children }: { children: React.ReactNode}) => {
    const [facturas, setFacturas] = useState<Factura[]>([]);

    return <FacturacionContext.Provider value={{ facturas }}>
        { children }
    </FacturacionContext.Provider>
};