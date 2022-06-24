import { useContext, useState } from "react";
import DataTable from "react-data-table-component";
import { Button } from "../../../common/ui/Atoms";
import {
    FacturacionContext,
    IFacturaFilter,
} from "../context/facturacion.context";
import { Factura, FacturaStatus } from "../models";
import { FacturaFilter } from "./filter";

export const FacturaPage = () => {
    const columns = [
        {
            name: "Id",
            selector: (row: Factura) => row.id,
        },
        {
            name: "Nro. Factura",
            selector: (row: Factura) => row.numeroFactura,
        },
        {
            name: "NIT",
            selector: (row: Factura) => row.nit,
        },
        {
            name: "Razon Social",
            selector: (row: Factura) => row.razonSocial,
        },
        {
            name: "Estado",
            cell: (row: Factura) =>
                row.estado === FacturaStatus.DECLARADA ? (
                    <span className="tag is-light is-success">Declarado</span>
                ) : (
                    <span className="tag is-light">No Declarado</span>
                ),
        },
    ];

    const { facturas, loading } = useContext(FacturacionContext);
    const [filters, setFilters] = useState<IFacturaFilter>({
        from: new Date(),
        to: new Date(),
    });

    return (
        <div className="columns is-multiline">
            <div className="column is-full">
                <div className="container is-flex is-justify-content-end">
                    <div className="mx-2">
                        <Button primary text="Declarar" onClick={() => {}} />
                    </div>
                    <div className="mx-2">
                        <Button
                            primary
                            text="Declarar Todos"
                            onClick={() => {}}
                        />
                    </div>
                </div>
            </div>
            <div className="column">
                <FacturaFilter onFilterChange={setFilters} />
            </div>
            <div className="column is-full">
                <DataTable
                    columns={columns}
                    data={facturas}
                    progressPending={loading}
                    selectableRows
                    pagination
                    pointerOnHover
                    highlightOnHover
                />
            </div>
        </div>
    );
};
