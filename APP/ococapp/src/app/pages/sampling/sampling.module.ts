import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SamplingPageRoutingModule } from './sampling-routing.module';

import { SamplingPage } from './sampling.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SamplingPageRoutingModule
  ],
  declarations: [SamplingPage]
})
export class SamplingPageModule {}
