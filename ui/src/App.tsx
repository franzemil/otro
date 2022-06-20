import { useState } from 'react';
import { DateRange } from './common/ui/Atoms/DateRangePicker';
import { NavBar } from './common/ui/Molecules/navbar';
import { PageTemplate } from './common/ui/Templates';
import { Facturacion } from './domain/facturacion/context/facturacion.context';
import { FacturaPage } from './domain/facturacion/pages/facturas.page';
import "./styles/index.scss"

function App() {
  const [range, setRange] = useState<DateRange>({ startDate: new Date(), endDate: new Date() });

  return (
    <section className="hero has-background-white-ter">
      <div className="hero-head">
        <NavBar />
      </div>
      <div className="hero-body is-align-content-flex-start">
        <div className="container">
          <Facturacion>
            <PageTemplate>
              <FacturaPage />
            </PageTemplate>
          </Facturacion>
        </div>
      </div>
    </section>
  );
}

export default App;
