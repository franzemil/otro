import ChevronDownIcon from "@heroicons/react/solid/ChevronDownIcon";
import ChevronUpIcon from "@heroicons/react/solid/ChevronUpIcon";
import React, { useEffect, useState } from "react";
import {
    DateRange,
    DateRangePicker,
} from "../../../common/ui/Atoms/DateRangePicker";
import { TextField } from "../../../common/ui/Atoms/textfield";
import { IFacturaFilter } from "../context/facturacion.context";

export interface FacturaFilterProps {
    onFilterChange: (filters: IFacturaFilter) => void;
}

export const FacturaFilter = ({ onFilterChange }: FacturaFilterProps) => {
    const [filters, setFilters] = useState<IFacturaFilter>({
        from: new Date(),
        to: new Date(),
    });

    const [dates, setDates] = useState<DateRange>({
        startDate: new Date(),
        endDate: new Date(),
    });
    const [showFilter, setShowFilter] = useState(false);

    useEffect(() => {
        setFilters((f) => ({ ...f, to: dates.endDate, from: dates.startDate }));
    }, [dates]);

    useEffect(() => {
        onFilterChange(filters);
    }, [filters]);

    return (
        <React.Fragment>
            <a
                className="title is-6 is-flex is-align-content-flex-start"
                onClick={() => setShowFilter((f) => !f)}
            >
                <span>{showFilter ? "Hide filters" : "Show filters"} </span>
                {showFilter ? (
                    <ChevronUpIcon height={20} width={20} />
                ) : (
                    <ChevronDownIcon height={20} width={20} />
                )}
            </a>
            <div className={showFilter ? "box" : "is-hidden"}>
                <div className="columns">
                    <div className="column">
                        <div className="columns is-multiline">
                            <div className="column is-full">
                                <TextField
                                    label="Numero de Factura"
                                    helpText="Ingresa el Numero de Factura"
                                />
                            </div>
                            <div className="column is-full">
                                <TextField
                                    label="NIT"
                                    helpText="Ingresa el NIT asociado a la factura"
                                />
                            </div>
                            <div className="column is-full">
                                <TextField
                                    label="Razon Social"
                                    helpText="Ingresa la razon social de la factura"
                                />
                            </div>
                        </div>
                    </div>
                    <div className="column">
                        <DateRangePicker dates={dates} setDates={setDates} />
                    </div>
                </div>
            </div>
        </React.Fragment>
    );
};
