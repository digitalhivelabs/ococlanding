import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SamplingPage } from './sampling.page';

const routes: Routes = [
  {
    path: '',
    component: SamplingPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SamplingPageRoutingModule {}
