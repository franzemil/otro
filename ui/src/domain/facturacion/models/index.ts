export const enum FacturaStatus {
    DECLARADA,
    PENDIENTE
}


export interface Factura {
    id: number;
    numeroFactura: number;
    nit: string;
    razonSocial: string;
    fechaPago: Date;
    estado: FacturaStatus
}