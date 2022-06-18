export const enum FacturaStatus {
    DECLARADA,
    PENDIENTE
}


export interface Factura {
    id: string;
    facturaRef: string;
    cuf: string;
    status: FacturaStatus
}