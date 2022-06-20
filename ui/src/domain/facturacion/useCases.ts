import { Factura, FacturaStatus } from "./models";

export function getFacturas(nit: string | undefined, numeroFactura: number | undefined, from: Date, to: Date, pageSize: number, pageNumber: number): Promise<Factura[]> {
    const data = [
        {
            id: 1,
            numeroFactura: 123,
            nit: '123123',
            razonSocial: 'EULATE',
            fechaPago: new Date(),
            estado: FacturaStatus.DECLARADA
        },
        {
            id: 2,
            numeroFactura: 123,
            nit: '671231',
            razonSocial: 'PEREZ',
            fechaPago: new Date(),
            estado: FacturaStatus.PENDIENTE
        }
    ];
    return Promise.resolve([...data, ...data, ...data, ...data, ...data, ...data]);
};