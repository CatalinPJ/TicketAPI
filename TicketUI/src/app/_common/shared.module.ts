import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DevextremeModule } from './devextreme-module/devextreme.module';
import { AuthGuard } from './guards/auth.guard';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  exports: [DevextremeModule, HttpClientModule],
  providers: [AuthGuard],
})
export class SharedModule {}
