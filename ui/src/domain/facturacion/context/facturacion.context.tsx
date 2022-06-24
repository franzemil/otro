import React, { useEffect, useState } from "react";
import { Factura } from "../models";
import { getFacturas } from "../useCases";


export interface IFacturacionContext {
    facturas: Factura[];
    loading: boolean;
}

export interface IFacturaFilter {
    nit?: string;
    numeroFactura?: number;
    from: Date;
    to: Date;
}

export interface IPage {
    pageSize: number;
    pageNumber: number;
}

export const FacturacionContext = React.createContext<IFacturacionContext>({ facturas: [], loading: true });

export const Facturacion = ({ children }: { children: React.ReactNode}) => {
    const [facturas, setFacturas] = useState<Factura[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [filters, setFilters] = useState<IFacturaFilter>({
        to: new Date(),
        from: new Date()
    });
    const [page, setPage] = useState<IPage>({ pageSize: 25, pageNumber: 1 });

    useEffect(() => {
        setLoading(false);
        getFacturas(filters.nit, filters.numeroFactura, filters.from, filters.to, page.pageNumber, page.pageSize).then(facturas => {
            setFacturas(facturas);
        }).finally(() => {
            setLoading(false);
        });
    }, [filters, page]);

    return <FacturacionContext.Provider value={{ facturas, loading }}>
        { children }
    </FacturacionContext.Provider>
};