import React, { useContext, useState } from 'react'
import DataTable from 'react-data-table-component'
import { Button, DateRangePicker } from '../../../common/ui/Atoms';
import { DateRange } from '../../../common/ui/Atoms/DateRangePicker';
import { TextField } from '../../../common/ui/Atoms/textfield';
import { FacturacionContext, IFacturaFilter } from '../context/facturacion.context';
import { Factura, FacturaStatus } from '../models';
import { FacturaFilter } from './filter';
import { ChevronDownIcon, ChevronUpIcon } from '@heroicons/react/solid';

export const FacturaPage = () => {
    const columns = [
        {
            name: 'Id',
            selector: (row: Factura) => row.id,
        },
        {
            name: 'Nro. Factura',
            selector: (row: Factura) => row.numeroFactura,
        },
        {
            name: 'NIT',
            selector: (row: Factura) => row.nit,
        },
        {
            name: 'Razon Social',
            selector: (row: Factura) => row.razonSocial,
        },
        {
            name: 'Estado',
            cell: (row: Factura) => (row.estado === FacturaStatus.DECLARADA ? (<span className="tag is-success">Declarado</span>) : (<span className="tag is-danger">No Declarado</span>))
        }
    ];


    const { facturas, loading } = useContext(FacturacionContext);
    const [showFilter, setShowFilter] = useState(false);
    const [filters, setFilters] = useState<IFacturaFilter>({ from: new Date(), to: new Date() });

    return (
        <div className="columns is-multiline">
            <div className="column is-full">
                <div className="container is-flex is-justify-content-space-around">
                    <Button primary text="Declarar" onClick={() => { }} />
                    <Button primary text="Declarar Todos" onClick={() => { }} />
                </div>
            </div>
            <div className="column">
                <a className="title is-6 is-flex is-align-content-flex-start" onClick={() => setShowFilter(f => !f)}>
                    <span>{ showFilter ? 'Hide filters' : 'Show filters' } </span>
                    { showFilter ? <ChevronUpIcon height={20} width={20} /> : <ChevronDownIcon height={20} width={20} /> }
                </a>
                { showFilter && <FacturaFilter onFilterChange={setFilters} /> }
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

    )
}
